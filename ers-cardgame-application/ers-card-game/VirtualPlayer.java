/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;
import tjw38tfinalproject.PlayDeck;
import tjw38tfinalproject.Player;
import tjw38tfinalproject.Slap;
import tjw38tfinalproject.UserPlayer;
import tjw38tfinalproject.VirtualPlayerClock;
import java.util.Random;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
/**
 *
 * @author scity
 */
public class VirtualPlayer extends Player implements Slap{
    
    public VirtualPlayerClock vClock;
    
    //constructor given a PlayDeck object, a UserPlayer object, and a double representing the difficulty setting
    public VirtualPlayer(PlayDeck mainDeck, UserPlayer userPlayer, double diffSeconds) {
        super(mainDeck);
        this.vClock = new VirtualPlayerClock(this, userPlayer, diffSeconds);
    }
    
    //implementation of slap() method from Slap interface
    @Override
    public void slap(){
        int mainSize = mainDeck.deck.size();
        
             for(int i = 0; i < mainSize; i++){
            playerDeck.deck.add(mainDeck.deck.get(0));
            mainDeck.deck.remove(0);
        }
        mainDeck.deck.trimToSize();
        vClock.vTurn = true;        
    }
}