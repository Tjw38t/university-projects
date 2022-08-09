/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tjw38tfinalproject;

import tjw38tfinalproject.FXMLDocumentController;
import tjw38tfinalproject.Switchable;
import static tjw38tfinalproject.Switchable.getControllerByName;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;

/**
 * FXML Controller class
 *
 * @author scity
 * This is the controller for MenuFXML.fxml
 */
public class MenuFXMLController extends Switchable implements Initializable {

    @FXML
    private Button playBtn;
    @FXML
    private Button aboutBtn;
    @FXML
    public Button diffBtn;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
        //Action for "Play Game" button
        playBtn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                FXMLDocumentController controller = (FXMLDocumentController)getControllerByName("FinalView");
                if(controller != null){
                controller.newGame();
                }
                
                Switchable.switchTo("FinalView");
            }
        });
        
        //Action for "About/Rules" button
        aboutBtn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                Switchable.switchTo("AboutFXML");
            }
        });
        
        //Action for the difficulty button
        diffBtn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                if(diffBtn.getText().equals("Easy")){
                    diffBtn.setText("Medium");
                }
                else if(diffBtn.getText().equals("Medium")){
                    diffBtn.setText("Hard");
                }
                else if(diffBtn.getText().equals("Hard")){
                    diffBtn.setText("Easy");
                }
            }
        });
    }    
    
}
