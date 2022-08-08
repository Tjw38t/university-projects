/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.Suit;
import javafx.scene.image.Image;

/**
 *
 * @author scity
 * class for creating a PlayingCard object
 */
public class PlayingCard {
    
    protected String name;
    protected int value;
    protected Suit suit;
    public String cardImageName = "";
    public Image cardImage;
    
    //constructor creates card given a value and a suit
    public PlayingCard(int value, Suit suit){
        this.value = value;
        this.suit = suit;
        this.name = setCardName(value, suit);
        this.cardImageName = setCardImageName(value, suit) + ".png";
        this.cardImage = new Image(getClass().getResourceAsStream("cardimgs/" + cardImageName));
    }
    
    //function sets the String name given the PlayingCard object's value and suit
    public String setCardName(int value, Suit suit){
        String valueString = "";
        String suitString = "";
        
        switch(value){
            case 1:
                valueString = "Ace of ";
                break;
                
            case 2:
                valueString = "Two of ";
                break;
                
            case 3:
                valueString = "Three of ";
                break;
                
            case 4:
                valueString = "Four of ";
                break;
                
            case 5:
                valueString = "Five of ";
                break;
            case 6:
                valueString = "Six of ";
                break;
                
            case 7:
                valueString = "Seven of ";
                break;
                
            case 8:
                valueString = "Eight of ";
                break;
                
            case 9:
                valueString = "Nine of ";
                break;
                
            case 10:
                valueString = "Ten of ";
                break;
                
            case 11:
                valueString = "Jack of ";
                break;
                
            case 12:
                valueString = "Queen of ";
                break;
                
            case 13:
                valueString = "King of ";
                break;
            
        }
        
        switch(suit){
            case CLUBS:
                suitString = "Clubs";
                break;
            
            case HEARTS:
                suitString = "Hearts";
                break;
                
            case SPADES:
                suitString = "Spades";
                break;
                
            case DIAMONDS:
                suitString = "Diamonds";
                break;
        }
        
        return(valueString + suitString);
    }
    
    //function sets the name of the Image which represents the playing card
    public String setCardImageName(int value, Suit suit){
        String valueString = "";
        String suitString = "";
        
        switch(value){
            case 1:
                valueString = "A";
                break;
                
            case 2:
                valueString = "2";
                break;
                
            case 3:
                valueString = "3";
                break;
                
            case 4:
                valueString = "4";
                break;
                
            case 5:
                valueString = "5";
                break;
            case 6:
                valueString = "6";
                break;
                
            case 7:
                valueString = "7";
                break;
                
            case 8:
                valueString = "8";
                break;
                
            case 9:
                valueString = "9";
                break;
                
            case 10:
                valueString = "10";
                break;
                
            case 11:
                valueString = "J";
                break;
                
            case 12:
                valueString = "Q";
                break;
                
            case 13:
                valueString = "K";
                break;
            
        }
        
        switch(suit){
            case CLUBS:
                suitString = "C";
                break;
            
            case HEARTS:
                suitString = "H";
                break;
                
            case SPADES:
                suitString = "S";
                break;
                
            case DIAMONDS:
                suitString = "D";
                break;
        }
        
        return(valueString + suitString);
    }
}
