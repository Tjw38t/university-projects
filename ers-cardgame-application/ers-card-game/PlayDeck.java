/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.Deck;
import tjw38tfinalproject.PlayingCard;

/**
 *
 * @author scity
 */
public class PlayDeck extends Deck{
    
    public PlayingCard firstCard;
    public PlayingCard secondCard;
    public PlayingCard thirdCard;
    public PlayingCard fourthCard;
    public PlayingCard bottomCard;
    public String reason = "";
    public boolean slapped = false;
    
    //returns a boolean representing whether it is legal to slap the deck
    public boolean checkIfSlappable(int dSize){
        bottomCard = deck.get(0);
        boolean retVal = false;
        if(dSize >= 1){
            firstCard = deck.get(dSize - 1);
        }
        if((dSize >= 2) && !retVal){
            secondCard = deck.get(dSize - 2);
            retVal = checkDouble();
            if(!retVal){
                retVal = checkMarriage();
            }
            if(!retVal){
                retVal = checkTens();
            }
        }
        if((dSize >= 3) && !retVal){
            thirdCard = deck.get(dSize - 3);
            retVal = checkSandwitch();
        }
        if((dSize >= 4) && !retVal){
            fourthCard = deck.get(dSize - 4);
            retVal = checkTopBottom();
            if(!retVal){
                retVal = checkFourInARow();
            }
        }
       
        return retVal;
    }    
    
    //checks if there is a double pattern
    public boolean checkDouble(){
        boolean retVal = false;
        if(firstCard.value == secondCard.value){
            retVal = true; 
            reason = "Double";
        }
        return retVal;
    }
    
    //checks if there is a sandwich pattern
    public boolean checkSandwitch(){
        boolean retVal = false;
        if(firstCard.value == thirdCard.value){
            
            retVal = true;  
            reason = "Sandwich";
        }
        return retVal;
    }
    
    //checks if there is a Top Bottom pattern
    public boolean checkTopBottom(){
        boolean retVal = false;
        if((firstCard.value == bottomCard.value)){
            retVal = true;   
            reason = "Top Bottom";
        }
        return retVal;
    }
    
//checks if there is a tens pattern    
    public boolean checkTens(){
        boolean retVal = false;
        if((firstCard.value + secondCard.value) == 10){
            retVal = true;       
            reason = "Tens";
        }
        return retVal;
    }
    
    //checks if there is a four in a row pattern
    public boolean checkFourInARow(){
        boolean retVal = false;
        if((secondCard.value == firstCard.value - 1) && (thirdCard.value == firstCard.value - 2) && (fourthCard.value == firstCard.value - 3)){
            retVal = true;  
            reason = "Four in a row";
        }
        else if((secondCard.value == firstCard.value +1 ) && (thirdCard.value == firstCard.value + 2) && (fourthCard.value == firstCard.value + 3)){
            retVal = true;  
            reason = "Four in a row";
        }
        return retVal;
    }
    
    //checks if there is a marriage pattern
    public boolean checkMarriage(){
        boolean retVal = false;
        if(((firstCard.value == 13) && (secondCard.value == 12)) || ((secondCard.value == 13) && (firstCard.value == 12))){
            retVal = true; 
            reason = "Marriage";
        }
        return retVal;
    }
    
}
