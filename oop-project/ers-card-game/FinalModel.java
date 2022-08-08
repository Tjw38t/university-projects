/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.AbstractModel;
import tjw38tfinalproject.PlayDeck;
import tjw38tfinalproject.PlayingCard;
import tjw38tfinalproject.UserPlayer;
import tjw38tfinalproject.VirtualPlayer;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
 *
 * @author scity
 * This Model connects to FXMLDocumentController
 */
public class FinalModel extends AbstractModel implements PropertyChangeListener {
    
    PlayDeck mainDeck;
    UserPlayer uPlayer;
    VirtualPlayer joshua; 
    double diffSeconds = 2;     
    
    //Constructor for the model
    public FinalModel(String diffString){
        setDifficulty(diffString);
        mainDeck = new PlayDeck();
        mainDeck.shuffleDeck();
        uPlayer = new UserPlayer(mainDeck);
        joshua = new VirtualPlayer(mainDeck, uPlayer, diffSeconds);
        joshua.vClock.addPropertyChangeListener(this);
    }
    
    //function for when the player attempts to place a card
    public void userCardPlace(){
        uPlayer.placeCard();
        if(uPlayer.playerDeck.deck.size() != 0){
        firePropertyChange("displayCardText", null, (mainDeck.deck.get(mainDeck.deck.size() - 1).name));
        firePropertyChange("cardImgView", null, (mainDeck.deck.get(mainDeck.deck.size() - 1)));
        
        System.out.println("\n\n\n\n\nmain:\n");
        mainDeck.printDeck();
        firePropertyChange("userScore", null, String.valueOf(uPlayer.playerDeck.deck.size()));
        firePropertyChange("joshuaScore", null, String.valueOf(joshua.playerDeck.deck.size()));
        firePropertyChange("mainScore", null, String.valueOf(mainDeck.deck.size()));
        uPlayer.uTurn = false;
        joshua.vClock.secondsRemaining = diffSeconds;
        }
        else{
            joshuaWin();
        }
    }
    
    //function for when the user attempts to slap
    public void userSlap(){
        uPlayer.slap();
        firePropertyChange("displayCardText", null, "You Got It!");
        firePropertyChange("userScore", null, String.valueOf(uPlayer.playerDeck.deck.size()));
        firePropertyChange("joshuaScore", null, String.valueOf(joshua.playerDeck.deck.size()));
        firePropertyChange("mainScore", null, String.valueOf(mainDeck.deck.size()));
    }
    
    //function for updating difficulty based on the setting from MenuFMLController
    public void setDifficulty(String diffString){
        if(diffString.equals("Easy")){
            diffSeconds = 3;
        }
        else if(diffString.equals("Medium")){
            diffSeconds = 2.25;
        }
        else if(diffString.equals("Hard")){
            diffSeconds = 1.75;
        }
    }
    
    //function for when the virtual player wins
    public void joshuaWin(){
        joshua.vClock.timeline.stop();
        firePropertyChange("userScore", null, String.valueOf(uPlayer.playerDeck.deck.size()));
        firePropertyChange("joshuaScore", null, String.valueOf(joshua.playerDeck.deck.size()));
        firePropertyChange("mainScore", null, String.valueOf(mainDeck.deck.size()));
        firePropertyChange("displayCardText", null, "You Lose. Play Again?");
        firePropertyChange("gameOver", null, true);
    }
    
    //function for when the user wins
    public void userWin(){
        joshua.vClock.timeline.stop();
        firePropertyChange("userScore", null, String.valueOf(uPlayer.playerDeck.deck.size()));
        firePropertyChange("joshuaScore", null, String.valueOf(joshua.playerDeck.deck.size()));
        firePropertyChange("mainScore", null, String.valueOf(mainDeck.deck.size()));
        firePropertyChange("displayCardText", null, "You Win! Play Again?");
        firePropertyChange("gameOver", null, true);
    }
    
    @Override
    public void propertyChange(PropertyChangeEvent evt) {
        
        if(evt.getPropertyName().equals("displayText")){
            firePropertyChange("displayCardText", null, (String)evt.getNewValue());
        }
        else if(evt.getPropertyName().equals("cardImageView")){
            firePropertyChange("cardImgView", null, (PlayingCard)evt.getNewValue());
        }
        else if(evt.getPropertyName().equals("userWin")){
            if((boolean)evt.getNewValue()){
                userWin();
            }
        }
        else if(evt.getPropertyName().equals("userScore")){
            firePropertyChange("userScore", null, (String)evt.getNewValue());
        }
        else if(evt.getPropertyName().equals("joshuaScore")){
            firePropertyChange("joshuaScore", null, (String)evt.getNewValue());
        }
        else if(evt.getPropertyName().equals("mainScore")){
            firePropertyChange("mainScore", null, (String)evt.getNewValue());
        }
    }
}
