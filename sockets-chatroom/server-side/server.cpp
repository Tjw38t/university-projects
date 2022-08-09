#include <stdio.h>
#include "winsock2.h"   //utilizing Socket API
#include <string>
#include <iostream>
#include <fstream>
using namespace std;
//Tyler Wilkins
//Student ID: 12546067
//03-18-2022

/*
* This program is the Server side of a Chatroom project created for CS4850 at the University of Missouri.
* This project was completed in C++ and used the provided skeleton client and server programs as a starting point.
* Because of this, parts of this file will be similar or the same as the starting server file provided.
* This server recieves data from a client and uses that data to implement four functions as would be seen in a chatroom.
* These functions are newuser, login, send, and logout.
* This server program uses a file "users.txt" to read and write username and passwords.
* For the server to work properly, this users.txt file must be located in the parent directory of the server executable.
* Please ensure users.txt is located in the proper directory before running the server.
*/

#define SERVER_PORT   16067 //port number = 1<last 4 of my student ID>
#define MAX_PENDING   5
#define MAX_LINE      290   //Max length to be sent across socket

    //This class represents a user and contains their important data
    class User {
    public:
        bool loggedIn = false;  //whether logged in
        string username;    //logged in username
        string password;    //logged in password
    };
    
    //This function is called if the send command is used. It takes a string recieved from the client, a user object, and a socket. 
    //The function echos the client's messsage and sends it back to the client to be printed.
    void clientSend(string rcv, User user, SOCKET s) {
        string delim = " ";
        string out = user.username + ":" + rcv.substr(rcv.find(delim), rcv.length() - rcv.find(delim)); //create a new string without the command and with the username shown
        cout << out;    //echo the message
        string sendStr = ">" + out;
        const char* str = sendStr.c_str();
        send(s, str, strlen(str), 0);   //send the message back to the client
    }

    //This function is called if the login command is used. It takes a socket, a string of the passed username, a string of the passed password, and a bool pointer to flag errors. 
    //The function checks the client's passed username and password against users.txt to see if the passed combination is valid.
    //If the combination is valid, the function returns a user object with a loggedIn value of true.
    //Otherwise, the loggedIn value of the user object is false 
    User clientLogin(SOCKET s, string clientUser, string clientPass, bool* txtErr) {
        User user;
        ifstream File("../users.txt");  //open users.txt
        if (!File.is_open()) {  //check for error opening users.txt
            cout << "Unable to open users.txt. Please ensure users.txt is located one directory above server.exe.\n";
            *txtErr = true; //set txtErr to true
            return user;    //return non-logged in user
        }

        string str;
        string delim1 = ",";
        string delim2 = ")";
        clientPass = clientPass.substr(0, clientPass.length() - 1); //remove newline character from passed password
        bool found = false;
        while (getline(File, str)) {    //get line from users.txt
            string username = str.substr(1, str.find(delim1) - 1);  //isolate username from users.txt
            string pass = str.substr(str.find(delim1) + 2, str.find(delim2) - (str.find(delim1) + 2));  //isolate password from users.txt
            if ((username.compare(clientUser) == 0) && (pass.compare(clientPass) == 0)) {   //compare passed username and password with isolated username and password
                found = user.loggedIn = true;   //if a match, logged in 
                user.username = clientUser; //username = passed username
                user.password = clientPass; //password = passed user password
                break;
            }
        }
        File.close();   //close users.txt

        return user;    //return user
    }

    //This function is called if the logout command is used. It takes a user object, and a socket.
    //This function echose to the server and sends a message to the client confirming the logout of the user.
    //THis function then closes the socket on which the client was connected.
    void clientLogout(User user, SOCKET s) {
        string str = ">" + user.username + " left.\n";
        const char* left = str.c_str(); 
        send(s, left, strlen(left), 0); //send a message to client confirming logout
        cout << user.username + " logout.\n";   //echo logout confirmation
        closesocket(s); //close socket
    }

    //This function is called if the newuser command is used. It takes a user object, a socket, a string of the passed username, a string of the passed password, and a bool pointer to flag errors.
    //This function checks users.txt for a matching username to the passed username to determine if the user account already exists.
    //If the user account already exists, the function returns false.
    //if the user account does not exist, the function writes the passed username and password to users.txt and returns true.
    bool clientNewUser(User user, SOCKET s, string clientUser, string clientPass, bool* txtErr) {
        ifstream FileR("../users.txt"); //open users.txt to be read
        if (!FileR.is_open()) { //check for error opening users.txt
            cout << "Unable to open users.txt. Please ensure users.txt is located one directory above server.exe.\n";    //echo error
            *txtErr = true; //set txtErr to true
            return false;   //return false due to failure
        }

        string str;
        string delim1 = ",";
        string delim2 = ")";
        bool found = false; //bool representing whether a matching username was found
        while (getline(FileR, str)) {   //read users.txt line by line
            string username = str.substr(1, str.find(delim1) - 1);  //isolate username
            if ((username.compare(clientUser) == 0)) {  //check if username matches passed username
                found = true;   //fount = true
                break;
            }
        }
        FileR.close();  //close users.txt

        if (!found) {   //if no matching username
            ofstream FileW("../users.txt", ios::in | ios::out | ios::ate);  //open users.txt for writing at end of file 
            if (!FileW.is_open()) { //check for error opening users.txt
                cout << "Unable to open users.txt. Please ensure users.txt is located one directory above server.exe.\n";    //echo error
                *txtErr = true; //set errTxt to true
                return false;   //return false due to failure
            }

            clientPass = clientPass.substr(0, clientPass.length() - 1); //remove newline character from passed password
            FileW << "\n(" + clientUser + ", " + clientPass + ")";  //write username and password to users.txt as: (<username>, <password>)
            FileW.close();  //close users.txt
        }

        return !found;  //return opposite of found value
    }

    //main function to run server program. 
   void main() {
   
    //Initialize Winsock.
    //Function taken from provided skeleton server program.
      WSADATA wsaData;
      int iResult = WSAStartup( MAKEWORD(2,2), &wsaData );  //initialize
      if ( iResult != NO_ERROR ){
         cout << "Error at WSAStartup()\n";
         return;
      }
   
    // Create a socket.
    //Function taken from provided skeleton server program.
      SOCKET listenSocket;
      listenSocket = socket( AF_INET, SOCK_STREAM, IPPROTO_TCP );   
      if ( listenSocket == INVALID_SOCKET ) {   //check if socket creation is successful
         printf( "Error at socket(): %ld\n", WSAGetLastError() );
         WSACleanup();
         return;
      }
   
    // Bind the socket.
    //Function taken from provided skeleton server program.
      sockaddr_in addr;
      addr.sin_family = AF_INET;
      addr.sin_addr.s_addr = INADDR_ANY; //use local address
      addr.sin_port = htons(SERVER_PORT);   //port = 16067
      if ( bind( listenSocket, (SOCKADDR*) &addr, sizeof(addr) ) == SOCKET_ERROR ) {    //check if bind is successful
         cout << "bind() failed.\n";
         closesocket(listenSocket);
         WSACleanup();
         return;
      }
   
    // Listen on the Socket.
    //Function taken from provided skeleton server program.
      if ( listen( listenSocket, MAX_PENDING ) == SOCKET_ERROR ){   //check if listening is successful
         cout << "Error listening on socket.\n";
         closesocket(listenSocket);
         WSACleanup();
         return;
      }
   
    // Accept connections.
    //Create necessary variables.
      SOCKET s; //socket to connect to client
      User user;    //user object to store user data
      bool connected = false;   //bool representing whether socket is open
      cout << "\nMy chat room server. Version One.\n\n"; 
          while(1){ //infinite loop to keep erver running
              if (!connected) { //checkes whether there is a connection over socket s
                  s = accept(listenSocket, NULL, NULL); //accept a connection to the client
                  if (s == SOCKET_ERROR) {  //check for error
                      cout <<"accept() error \n";   //echo error message
                      closesocket(listenSocket);    //close listen socket
                      WSACleanup(); 
                      return;
                  }
                  connected = true; //connection established
              }
          

          // Send and receive data.
          char buf[MAX_LINE];   //define buffer
          int len = recv(s, buf, MAX_LINE, 0);  //recieve data from client 
          buf[len] = 0; //add string terminator to end of passed data
          string rcv = buf; //create a string from buffer
          string delim = " ";
          string command = rcv.substr(0, rcv.find(delim));  //isolate command at begining of recieved string

          //Identify and execute recieved command.
          if ((command.compare("send") == 0) || (command.compare("send\n") == 0)) { //check if the command "send" was recieved
              if (user.loggedIn) {  //if user is loggged in
                  clientSend(rcv, user, s); //call clientSend()
              }
              else {    //if user is not logged in
                  char* denied = ">Denied. Please login first.\n";  
                  send(s, denied, strlen(denied), 0);   //send client a response and request to log in
              }
          }

          else if (command.compare("login") == 0) { //check if command "login" was recieved
              if (!user.loggedIn) { //if user is not logged in
                  char* tokArr[3];  //create a char* array to hold char* tokens
                  char* tok;
                  int i = 0;
                  tok = strtok(buf, " ");   //tokenize recieved buffer using " " as the delimiter
                  while (tok != 0) {    //continue tokenization
                      tokArr[i] = tok;  //assign tokens to tokArr
                      i++;
                      tok = strtok(0, " ");
                  }

                  bool txtErr = false;  //bool representing whether a file error occured
                  user = clientLogin(s, (string)tokArr[1], (string)tokArr[2], &txtErr); //call clientLogin()

                  if (user.loggedIn) {  //if user is now logged in
                      cout << user.username + " login.\n";  //echo login confirmation
                      char* confirm = ">login confirmed\n";     
                      send(s, confirm, strlen(confirm), 0); //send login confirmation
                  }

                  else if(txtErr) { //if a file error ooccured
                      char* denied = ">ERROR. Unable to access users.txt\n";
                      send(s, denied, strlen(denied), 0);   //send error message
                  }

                  else {    //if login failed 
                      char* denied = ">Denied. User name or password incorrect.\n";
                      send(s, denied, strlen(denied), 0);   //send denial message
                  }
              }

              else {    //if user was already logged in
                  char* denied = ">Denied. Already logged in.\n";
                  send(s, denied, strlen(denied), 0);   //send denial message
              }
          }

          else if (command.compare("logout\n") == 0) {  //check if command "logout" was recieved
              if (user.loggedIn) {  //if user is logged in
                  clientLogout(user, s);    //call clientLogout()
                  connected = false;    //connected = false
                  user.loggedIn = false;    //logged in = false
              }

              else {    //user is already logged out
                  char* denied = ">Denied. Please login first.\n";
                  send(s, denied, strlen(denied), 0);   //send denial message
              }
          }

          else if (command.compare("newuser") == 0) {   //check if command "newuser" was recieved
              if (!user.loggedIn) { //if user is not logged in
                  char* tokArr[3];  //create a char* array to hold char* tokens
                  char* tok;
                  int i = 0;
                  tok = strtok(buf, " ");   //tokenize recieved buffer using " " as the delimiter
                  while (tok != 0) {    //continue tokenization
                      tokArr[i] = tok;  //assign tokens to tokArr
                      i++;
                      tok = strtok(0, " ");
                  }

                  bool success = false; //bool representing success of function
                  bool txtErr = false;  //bool representing whether a file error occured
                  success = clientNewUser(user, s, (string)tokArr[1], (string)tokArr[2], &txtErr);  //call clientNewUser()

                  if (success) {    //if clientNewUser was successful
                      cout << "New user account created.\n";    //echo success message
                      char* confirm = ">New user account created. Please login.\n";
                      send(s, confirm, strlen(confirm), 0); //send confirmation message
                  }

                  else if (txtErr) {    //if a file error occured
                      char* denied = ">ERROR. Unable to access users.txt\n";
                      send(s, denied, strlen(denied), 0);   //send error message to client
                  }

                  else {    //if clientNewUser failed
                      char* denied = ">Denied. User account already exists.\n";
                      send(s, denied, strlen(denied), 0);   //send denial message
                  }
              }

              else {    //user is already logged in
                  char* denied = ">Denied. Already logged in.\n";
                  send(s, denied, strlen(denied), 0);   //send denial message
              }
          }

          else {    //command recieved was not recognized
              char* denied = ">Denied. Please enter valid command.\n";
              send(s, denied, strlen(denied), 0);   //send denial message
          }
      }
         closesocket(listenSocket); //close listenSocket
   }
   

