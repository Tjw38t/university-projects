#include <stdio.h>
#include "winsock2.h"   //utilizing Socket API
#include <string.h>
#include <iostream>
using namespace std;
//Tyler Wilkins
//Student ID: 12546067
//03-18-2022

/*
* This program is the Client side of a Chatroom project created for CS4850 at the University of Missouri.
* This project was completed in C++ and used the provided skeleton client and server programs as a starting point.
* Because of this, parts of this file will be similar or the same as the starting client file provided.
* This client connects to a server, recieves data from a user, and checks that data for conformity to four functions as would be seen in a chatroom.
* These functions are newuser, login, send, and logout.
* Once the input has been checked and verified, the input is sent to the server for execution.
* This client takes the address of the server as an argument when running the client executable.
* To run the client.exe on the same machine as the server, use the address 127.0.0.1 such as: ./client 127.0.0.1  
*/

#define SERVER_PORT  16067  //port number = 1<last 4 of my student ID>
#define MAX_LINE      290   //Max length to be sent across socket

//This function is called to check whether the input provided by the user is valid for the send command.
//The function takes a string of the user input
//the function returns true if the input is valid and false if it is not.
bool sendCheck(string str) {
    bool result = false;    //initialize result to false
    if (((str.length() - 5) >= 1) && ((str.length() - 5) <= 264)) {    //check length of message. length(total input) - length("send ")
        result = true;  //message is valid
    }
    return result;  //return result
}

//This function is called to check whether the input provided by the user is valid for the login command.
//The function takes a char* array of the tokenization of user input.
//the function returns true if the input is valid and false if it is not.
bool loginCheck(char* Arr[]) {
    bool result = false;    //initialize result to false
    if ((strcmp(Arr[1], "") != 0) && (strcmp(Arr[2], "") != 0) && (strcmp(Arr[3], "") == 0)) {  //check if input has correct number of arguments 
        result = true;  //input is valid
    }
    return result;  //return result
}

//this function is called to check whether the input provided by the user is valid for the logout command.
//The function takes a char* array of the tokenization of user input.
//The function returns true if the input is valid and false if it is not.
bool logoutCheck(char* Arr[]) {
    bool result = false;    //initialize result to false
    if (strcmp(Arr[1], "") == 0) {  //check if the command word was the only input
        result = true;  //input is valid
    }
    return result;  //return result
}

//This function is called to check whether the input provided by the user is valid for the newuser command.
//The function takes a char* array of the tokenization of user input.
// the function will echo and send error messages as needed.
//The function returns true if the input is valid and false if it is not.
bool newuserCheck(char* Arr[]) {
    bool result = false;    //initialize result to false
    if ((strcmp(Arr[1], "") != 0) && (strcmp(Arr[2], "") != 0) && (strcmp(Arr[3], "") == 0)) {  //check if there are the correct number of arguments

        if ((strlen(Arr[1]) >= 3) && (strlen(Arr[1]) <= 32)) {  //check length of passed username

            if ((strlen(Arr[2]) >= 4) && (strlen(Arr[2]) <= 8)) {   //check length of passed password
                result = true;  //input is thusfar valid
            }

            else { //if password length is invalid
                cout << ">Denied. Password must be between 4 and 8 characters.\n";  //echo denial message
            }
        }

        else {  //if username length is invalid
            cout << ">Denied. Username must be between 3 and 32 characters.\n"; //echo denial message
        }
    }

    if (result) {   //if user input is valid thus far
        for (int i = 0; i < strlen(Arr[1]); i++) {  //loop to check each character of passed username
            char c1 = '(';  //initialize invalid characters
            char c2 = ')';
            char c3 = ',';
            if ((Arr[1][i] == c1) || (Arr[1][i] == c2) || (Arr[1][i] == c3)) {  //check wherther there are any characters in passed username which would interfere with the ability to read the username from users.txt
                result = false; //result = false
                cout << ">Username and Password cannot contain '(', ')', or ','\n"; //echo error message
                break;
            }
        }
        for (int i = 0; i < strlen(Arr[2]); i++) {  //loop to check each character of passed username
            char c1 = '(';  //initialize invalid characters
            char c2 = ')';
            char c3 = ',';
            if ((Arr[2][i] == c1) || (Arr[2][i] == c2) || (Arr[2][i] == c3)) {  //check wherther there are any characters in passed username which would interfere with the ability to read the username from users.txt
                result = false; //result = false
                cout << ">Username and Password cannot contain '(', ')', or ','\n"; //echo error message
                break;
            }
        }
    }
    return result;  //return result
}

//main function to run client program.
   void main(int argc, char **argv) {
   
      if (argc < 2){
         cout << "\nUseage: client serverName\n";
         return;
      }
   
    // Initialize Winsock.
    //Function taken from provided skeleton client program.
      WSADATA wsaData;
      int iResult = WSAStartup( MAKEWORD(2,2), &wsaData );  //initialize
      if ( iResult != NO_ERROR ){
         cout << "Error at WSAStartup()\n";
         return;
      }
   
   	//translate the server name or IP address to resolved IP address
    //Function taken from provided skeleton client program.
      unsigned int ipaddr;
   	// If the user input is an alpha name for the host, use gethostbyname()
   	// If not, get host by addr (assume IPv4)
      if (isalpha(argv[1][0])) {   // host address is a name  
         hostent* remoteHost = gethostbyname(argv[1]);
         if ( remoteHost == NULL){
            cout << "Host not found\n";
            WSACleanup(); 
            return;
         }
         ipaddr = *((unsigned long *) remoteHost->h_addr);
      }
      else {
          ipaddr = inet_addr(argv[1]);
      }
   
    // Create a socket.
    //Function taken from provided skeleton client program.
      SOCKET s;
      s = socket( AF_INET, SOCK_STREAM, IPPROTO_TCP );
      if ( s == INVALID_SOCKET ) {
         printf( "Error at socket(): %ld\n", WSAGetLastError() );   //check for socket creation error
         WSACleanup();
         return;
      }
   
    // Connect to a server.
    //Function taken from provided skeleton client program.
      sockaddr_in addr;
      addr.sin_family = AF_INET;
      addr.sin_addr.s_addr = ipaddr;
      addr.sin_port = htons( SERVER_PORT );
      if ( connect( s, (SOCKADDR*) &addr, sizeof(addr) ) == SOCKET_ERROR) { //check if connection failed
         cout << "Failed to connect.\n";
         WSACleanup();
         return;
      }

      cout << "\nMy chat room client. Version One.\n\n";    //echo message
      while (1) {   //begin infinite loop until closed by logout
          // Send and receive data.
          char getBuf[2 * MAX_LINE];    //define buffer
          cout << ">";  //echo indicator character
          fgets(getBuf, sizeof(getBuf), stdin); //get char* from user
          string str = getBuf;  //create string identical to buffer

          bool tooLong = false;
          if (str.length() > 290) {
              cout << ">Denied. Input must be less than or equal to 290 characters.\n"; //check whether user input is too long
              str = "error";    //set string to error
              tooLong = true;
          }

          char* tokArr[4];  //create a char* array to hold char* tokens
          for (int i = 0; i < 4; i++) {
              tokArr[i] = "";   //initialize tokens to empty char*
          }
          char* tok;
          int i = 0;
          tok = strtok(getBuf, " ");    //tokenize recieved buffer using " " as the delimiter
          while ((tok != 0) && (i < 4)) {   //continue tokenization
              tokArr[i] = tok;  //assign tokens to tokArr
              i++;
              tok = strtok(0, " ");
          }

          const char* buf = str.c_str();    //create consst char* buffer identical to user input;

          if (((strcmp(tokArr[0], "send\n") == 0) || (strcmp(tokArr[0], "send") == 0)) && !tooLong) {    //if command "send" was input
              if (sendCheck(str)) { //call sendCheck() and if true
                  send(s, buf, strlen(buf), 0); //send user input to server
                  int len = recv(s, getBuf, MAX_LINE, 0);   //recieve response from server
                  getBuf[len] = 0;  //add string terminator to end of response
                  printf("%s", getBuf); //echo server response
              }

              else {    //sendCheck was false
                  cout << ">Denied. Message must bemore than 0 and less than 265 characters.\n";   //echo denial message
              }
          }

          else if (((strcmp(tokArr[0], "login\n") == 0) || (strcmp(tokArr[0], "login")) == 0) && !tooLong) {  //if command "login" was input
              if (loginCheck(tokArr)) { //call loginCheck and if true
                  send(s, buf, strlen(buf), 0); //send user input to server
                  int len = recv(s, getBuf, MAX_LINE, 0);   //recieve response from server
                  getBuf[len] = 0;  //add string terminator to end of response
                  printf("%s", getBuf); //echo server response
              }

              else {    //loginCheck was false
                  cout << ">Denied. Usage: login <Username> <Password>\n";  //echo denial message
              }
          }

          else if (((strcmp(tokArr[0], "logout\n") == 0) || (strcmp(tokArr[0], "logout") == 0)) && !tooLong) {    //if "logout" was input
              if (logoutCheck(tokArr)) {    //call logoutCheck() and if true
                  send(s, buf, strlen(buf), 0); //send user input to server
                  int len = recv(s, getBuf, MAX_LINE, 0);   //recieve response from server
                  getBuf[len] = 0;  //add string terminator to end of response
                  printf("%s", getBuf); //echo server response

                  if (strcmp(getBuf, ">Denied. Please login first.\n") != 0) {  //check if logout was not denied
                      if (shutdown(s, SD_SEND) == SOCKET_ERROR) {    //shutdown from clientside and check for shutdown error
                          printf("shutdown failed: %d\n", WSAGetLastError());   //echo error message
                          closesocket(s);   //close socket
                          WSACleanup();
                          return;   //exit client
                      }

                      cout << "\n"; //echo newlinw
                      closesocket(s);   //close socket
                      return;
                  }
              }

              else {    //logoutCheck was false
                  cout << ">Denied. Usage: logout\n";   //echo denial message
              }
          }

          else if (((strcmp(tokArr[0], "newuser\n") == 0) || (strcmp(tokArr[0], "newuser") == 0)) && !tooLong) {  //if "newuser" was input
              if (newuserCheck(tokArr)) {   //call newuserCheck() and if true
                  send(s, buf, strlen(buf), 0); //send user input to server
                  int len = recv(s, getBuf, MAX_LINE, 0);   //recieve response from server
                  getBuf[len] = 0;  //add string terminator to end of response
                  printf("%s", getBuf); //echo server response
              }

              else {    //newuserCheck was false
                  cout << ">Denied. Usage:newuser <Username> <Password>\n"; //echo denial message
              }
          }

          else {    //command input is not recognized
              cout << ">Denied. Please enter a valid command.\n";   //echo denial message
          }
      }
      closesocket(s);   //close socket s
   }
