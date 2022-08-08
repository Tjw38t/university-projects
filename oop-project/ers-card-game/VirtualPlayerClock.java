/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.AbstractModel;
import tjw38tfinalproject.UserPlayer;
import tjw38tfinalproject.VirtualPlayer;
import java.util.Random;
import javafx.animation.Animation;
import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.event.ActionEvent;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
import javafx.util.Duration;

/**
 *
 * @author scity
 * KeyFrame implementation based on code by Professor Wergeles
 */
public class VirtualPlayerClock extends AbstractModel{
    private KeyFrame keyFrame;
    public Timeline timeline;
    private final double tickTimeInSeconds = 0.01;
    public double secondsRemaining = -1;
    public VirtualPlayer vPlayer;
    public UserPlayer userPlayer;
    public double diffSeconds;
    boolean ran = false;
    boolean srUpdated = false;
    boolean randRoll = true;
    boolean vTurn = false;
    
    //constructor given VirtualPlayer object, UserPlayer object, and double representing difficulty
    public VirtualPlayerClock (VirtualPlayer vPlayer, UserPlayer userPlayer, double diffSeconds){
        this.vPlayer = vPlayer;
        this.diffSeconds = diffSeconds;
        setupClock();
        timeline.play();
        this.userPlayer = userPlayer;
    }
    
    //creates new keyFrame used to cound down to the VirtualPlayer object's next action
    public void setupClock() {
        keyFrame = new KeyFrame(Duration.millis(tickTimeInSeconds * 1000), (ActionEvent event) -> {
            virtualPlayerAction();
        });
        
        timeline = new Timeline(keyFrame);
        timeline.setCycleCount(Animation.INDEFINITE);
    }
    
    //function for having the VirtualPlayer object either place a card or slap
     private void virtualPlayerAction() {
        secondsRemaining -= tickTimeInSeconds;
        
        //check of the pile can be slapped and if there are any cards in the pile
        boolean slappable = false;
        if(vPlayer.mainDeck.deck.size() > 0){
            slappable = vPlayer.mainDeck.checkIfSlappable(vPlayer.mainDeck.deck.size());
            if(slappable && !srUpdated){
                secondsRemaining = diffSeconds;
                srUpdated = true;
            }
        }
        
        //if the pile cannot be legally slapped
        if(!slappable){
            
            //if the timer has run down to 0, the virtual player has not taken an action, and the user has not already slapped the deck 
            if(((((int)secondsRemaining == 0.0) && !ran) && !vPlayer.mainDeck.slapped)){
                //virtual player places card
                vPlayer.placeCard();
                
                //if the virtual player still has cards
                if(vPlayer.playerDeck.deck.size() != 0){
                //update the model and set secondsRemaining to a negative value
                userPlayer.uTurn = true;
                firePropertyChange("displayText", null, vPlayer.mainDeck.deck.get(vPlayer.mainDeck.deck.size() - 1).name);
                firePropertyChange("cardImageView", null, vPlayer.mainDeck.deck.get(vPlayer.mainDeck.deck.size() - 1));
                firePropertyChange("userScore", null, String.valueOf(userPlayer.playerDeck.deck.size()));
                firePropertyChange("joshuaScore", null, String.valueOf(vPlayer.playerDeck.deck.size()));
                firePropertyChange("mainScore", null, String.valueOf(vPlayer.mainDeck.deck.size()));
                System.out.println("\n\n\n\n\nmain:\n");
                vPlayer.mainDeck.printDeck();
                secondsRemaining = -1;
                //the virtual player has now taken an action, so ran = true
                ran = true;
                }
                else{
                    //else, let the model know the user has won
                    firePropertyChange("userWin", null, true);
                }
            }
            else{
               //it is now safe to say the user has not taken their next action, so ran= false
               ran = false; 
            }
        }
        //else: the pile can be legally slapped
        else{
            //if the timer has run down to 0, the virtual player has not taken their action, the user has not slapped the pile, and the miss possibility has not already been set
            if((((int)secondsRemaining == 0.0) && !ran) && (!vPlayer.mainDeck.slapped && randRoll)){
                //initialize random number miss from 0 to 9
                Random missRand = new Random();
                int miss = missRand.nextInt(10);
                //the miss possibility has now been set
                randRoll = false;
                
                //if miss is greater or equal to 2 (80% chance), the virtual player will slap the pile
                if(miss >= 2){
                    //virtual player slaps the pile
                    vPlayer.slap();
                    userPlayer.uTurn = false;
                    //the model is updated usinf firepropertychange
                    firePropertyChange("displayText", null, "Slapped!! Reason: " + vPlayer.mainDeck.reason);
                    firePropertyChange("userScore", null, String.valueOf(userPlayer.playerDeck.deck.size()));
                    firePropertyChange("mainScore", null, String.valueOf(vPlayer.mainDeck.deck.size()));
                    System.out.println("\n\n\n\n\nmain:\n");
                    vPlayer.mainDeck.printDeck();
                    secondsRemaining = -1;
                    srUpdated = false;
                    //the virtual player has now taken an action, so ran = true
                    ran = true;
                }
                else{
                    
                }
            }
            else{
               if((int)secondsRemaining != 0.0){
                   randRoll = true;
               }
               ran = false;
            }
        }
        
        //if the virtual player just slapped the pile, it waits 5 seconds then places a card
        if(vTurn && (secondsRemaining < -5)){
            //virtual player places a card
            vPlayer.placeCard();
            //model is updated using firepropertychange
            firePropertyChange("userScore", null, String.valueOf(userPlayer.playerDeck.deck.size()));
            firePropertyChange("joshuaScore", null, String.valueOf(vPlayer.playerDeck.deck.size()));
            firePropertyChange("mainScore", null, String.valueOf(vPlayer.mainDeck.deck.size()));
            vTurn = false;
            userPlayer.uTurn =true;
            //if the virtual player still has vards in its hand
            if(vPlayer.playerDeck.deck.size() != 0){
                //update model
                firePropertyChange("displayText", null, vPlayer.mainDeck.deck.get(vPlayer.mainDeck.deck.size() - 1).name);
                firePropertyChange("cardImageView", null, vPlayer.mainDeck.deck.get(vPlayer.mainDeck.deck.size() - 1));
                System.out.println("\n\n\n\n\nmain:\n");
                vPlayer.mainDeck.printDeck();
                secondsRemaining = -1;
                
            }
            else{
                //let the model know the user has won
                firePropertyChange("userWin", null, true);
            }
        }
    }
}
