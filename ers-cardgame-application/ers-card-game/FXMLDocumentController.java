/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.FinalModel;
import tjw38tfinalproject.MenuFXMLController;
import tjw38tfinalproject.PlayDeck;
import tjw38tfinalproject.PlayingCard;
import tjw38tfinalproject.Switchable;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.event.EventHandler;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
/**
 *
 * @author scity
 * This is the controller for FinalView.fxml and connects to the model FinalModel
 */
public class FXMLDocumentController extends Switchable implements Initializable, PropertyChangeListener {
    PlayDeck mydeck;
    @FXML
    private Label label;
    @FXML
    private Button p1PlaceBtn;
    @FXML
    private Text cardDisplayText;
    @FXML
    private Text slapDisplayText;
    @FXML
    private Text p1CardCount;
    @FXML
    private Text p2CardCount;
    @FXML
    private Button p1SlapBtn;
    @FXML
    private Text mainCardCount;
    @FXML
    private ImageView cardImgView;
    
    FinalModel finalModel;
    
        
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        mydeck  = new PlayDeck();
        MenuFXMLController controller = (MenuFXMLController)getControllerByName("MenuFXML");
        if(controller != null){
            finalModel = new FinalModel(controller.diffBtn.getText());
        }
        finalModel.addPropertyChangeListener(this);
        
        //Action for "Place Card"/"Menu" button
        p1PlaceBtn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
               if(p1PlaceBtn.getText().equals("Place Card")){
                   finalModel.userCardPlace();
               }
                else{
                   newGame();
                   Switchable.switchTo("MenuFXML");
               }
            }
        });
        
        //Action for "SLAP"/"New Game" button
        p1SlapBtn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                if(p1SlapBtn.getText().equals("SLAP")){
                    finalModel.userSlap();
                }
                else{
                    newGame();
                }
            }
        });
    }    

    @FXML
    private void handleButtonAction(ActionEvent event) {
    }
   
    //Updates view and creates new model for a new game
    public void newGame(){
        MenuFXMLController controller = (MenuFXMLController)getControllerByName("MenuFXML");
        cardDisplayText.setText("Place First Card");
        cardImgView.setImage(new Image(getClass().getResourceAsStream("red_back.png")));
        p2CardCount.setText("Joshua:");
        p1CardCount.setText("You:");
        mainCardCount.setText("Pile:");
        p1SlapBtn.setText("SLAP");
        p1PlaceBtn.setText("Place Card");
        if(controller != null){
            finalModel = new FinalModel(controller.diffBtn.getText());
        }
        finalModel.addPropertyChangeListener(this);
        
    }
    
    @Override
    public void propertyChange(PropertyChangeEvent evt) {
        if(evt.getPropertyName().equals("displayCardText")){
            cardDisplayText.setText((String)evt.getNewValue());
        }
        else if(evt.getPropertyName().equals("cardImgView")){
            cardImgView.setImage(((PlayingCard)evt.getNewValue()).cardImage);
        }
        else if(evt.getPropertyName().equals("userScore")){
            p1CardCount.setText("You: " + (String)evt.getNewValue() + " cards");
        }
        else if(evt.getPropertyName().equals("joshuaScore")){
            p2CardCount.setText("Joshua: " + (String)evt.getNewValue() + " cards");
        }
        else if(evt.getPropertyName().equals("mainScore")){
            mainCardCount.setText("Pile: " + (String)evt.getNewValue() + " cards");
        }
        else if(evt.getPropertyName().equals("gameOver")){
            p1SlapBtn.setText("New Game");
            p1PlaceBtn.setText("Back to Menu");
        }
    }
}
