/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.PlayingCard;
import tjw38tfinalproject.Suit;
import java.util.*;
/**
 *
 * @author scity
 * This class is used to create ArrayList collections of PlayingCard objects
 */
public class Deck {
    protected ArrayList<PlayingCard> deck;
    
    //creates a full 52 card deck
    public Deck(){
        deck = new ArrayList();
        for(int s = 1; s <= 4; s++){
            Suit suit = Suit.CLUBS;

            switch(s){
                case 2:
                    suit = Suit.HEARTS;
                    break;
                case 3:
                    suit = Suit.SPADES;
                    break;
                case 4:
                    suit = Suit.DIAMONDS;
                    break;             
            }
            
            for(int v = 1; v <= 13; v++){
                deck.add(new PlayingCard(v, suit));
            }
      }
        System.out.println("in init:" + String.valueOf(deck.size()));
    }
    
    //creates a deck with a requested number of cards
    public Deck(int numRequested){
        deck = new ArrayList();
        for(int s = 1; s <= 4; s++){
            Suit suit = Suit.CLUBS;

            switch(s){
                case 2:
                    suit = Suit.HEARTS;
                    break;
                case 3:
                    suit = Suit.SPADES;
                    break;
                case 4:
                    suit = Suit.DIAMONDS;
                    break;             
            }
            
            for(int v = 1; v <= 13; v++){
                if(deck.size() < numRequested){
                    deck.add(new PlayingCard(v, suit));
                }
            }
      }
    }
    
    //randomizes the order of the deck ArrayList
    public void shuffleDeck(){
        Collections.shuffle(deck);
        Collections.shuffle(deck);
        Collections.shuffle(deck);
    }
    
    //prints the cards in the deck
    public void printDeck(){
        for(int i = 0; i< deck.size(); i++ ){
            
            System.out.println( String.valueOf(i + 1) + ": " + deck.get(i).name + "\n");
        }
    }
}
