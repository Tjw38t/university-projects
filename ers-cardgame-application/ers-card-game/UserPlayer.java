/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.PlayDeck;
import tjw38tfinalproject.Player;
import tjw38tfinalproject.Slap;

/**
 *
 * @author scity
 * class for creating a UserPlayer object
 */
public class UserPlayer extends Player implements Slap{
    public boolean uTurn = true;
    
    //constructor given a PlayDeck object
    public UserPlayer(PlayDeck mainDeck) {
        super(mainDeck);
    }
    
    //implementation of slap() method from Slap interface
    @Override
    public void slap(){
        boolean slappable = false;
        if(mainDeck.deck.size() != 0){
            slappable = mainDeck.checkIfSlappable(mainDeck.deck.size());
        }
        int mainSize = mainDeck.deck.size();
        if((slappable && !mainDeck.slapped) && (mainSize!=0)){
             
             for(int i = 0; i < mainSize; i++){
            playerDeck.deck.add(mainDeck.deck.get(0));
            mainDeck.deck.remove(0);
        }
        mainDeck.deck.trimToSize();
        mainDeck.slapped = true;
        }
        else if(!slappable && (mainSize != 0) && (playerDeck.deck.size() != 0)){
            mainDeck.deck.add(1, playerDeck.deck.get(0));
            playerDeck.deck.remove(0);
        }
    }
}
