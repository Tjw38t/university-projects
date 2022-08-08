/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.Deck;
import tjw38tfinalproject.PlayDeck;
import java.util.ArrayList;

/**
 *
 * @author scity
 * superclass for userPlayer and virtualPlayer classes
 */


public class Player {
   protected Deck playerDeck;
   protected PlayDeck mainDeck; 
   public static boolean userTurn = true;
   
   //class constructor given PlayDeck object
    public Player(PlayDeck mainDeck){
        playerDeck = new Deck(0);
        this.mainDeck = mainDeck;
        for(int i = 0; i < 26; i++){
            playerDeck.deck.add(mainDeck.deck.get(0));
            mainDeck.deck.remove(0);
        }
        mainDeck.deck.trimToSize();
    }
    
    //function for when the player places a card
    public boolean placeCard(){
        if(!playerDeck.deck.isEmpty()){
            mainDeck.deck.add(playerDeck.deck.get(0));
            playerDeck.deck.remove(0);
        }
        playerDeck.deck.trimToSize();
        mainDeck.slapped = false;
        return true;
    }
}

