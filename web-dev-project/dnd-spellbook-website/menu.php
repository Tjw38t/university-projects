<!DOCTYPE html>

<!--
Name: Tyler Wilkins
Pawprint: TJW38T
Date:09/25/2020
Challenge: Flex Box F20
-->
<?php 
    $username = empty($_COOKIE['username']) ? '' : $_COOKIE['username'];
    session_unset();
    session_destroy();
?>
<html lang="en">
    <head>
        
        <meta charset="utf-8">
        
        <link rel="stylesheet" type="text/css" href="Styles.css">
               
        <title>Projects</title>    
        
        
        <style>
            .projectCardTitle{
                display: block;
                text-align: center;
                margin-bottom: 10px;
                margin-top: 10px;
                font-size: 22px;
                font-family: 'Nova Cut', cursive;
                color: black;
                text-shadow:1px 1px goldenrod;
            }
            
             .projectCardDescFont{
                 font-family: 'Nova Cut', cursive;
                display: block;
                text-align: center;
                font-size: 15px;
                color: black;
            }
            
            #nav{
                display:block;
                margin: 0px;
                background-color:darkred;
                border-bottom: 3px ridge darkgoldenrod;
                width: 100%;
                max-height: 30px;
                position: fixed;
                top:0;
                left: 0;
                padding:0;
            }
            
            #signedIn{
                font-family: 'Nova Cut', cursive;
                color: goldenrod;
                text-shadow: 1px 1px black;
                text-decoration: none;
                position: fixed;
                top: 0;
                right: 0;
                margin-right: 20px;
                margin-top: 5px;
            }
            
            #navMenu{
                font-family: 'Nova Cut', cursive;
                color: goldenrod;
                text-shadow: 1px 1px black;
                text-decoration: none;
                position: fixed;
                top: 0;
                left: 0;
                margin-left: 20px;
                margin-top: 5px;
            }
            
        </style>


    </head>
    <body id="bodyId">
    <?php 
            switch($username){
                case '':
                    include("navOut.php");
                    break;
                    
                default:
                    include("navIn.php");
            }; ?>
    <div id="projectsWrapper">
            
            <div class="projectCardColumn clearFix" onclick="">
                <img class="projectCardImage" src="book.png" alt="Image here">
                
                <div class="projectCardDesc">
                    <span class="projectCardTitle">My Spellbook</span>
                    <p class="projectCardDescFont">Must be signed in to utilize</p>
                </div>
                
            </div>

            <div class="projectCardColumn clearFix">
                <img class="projectCardImage" src="Parchement.png" alt="Image here">
                
                <div class="projectCardDesc">
                    <span class="projectCardTitle">Spell Compendium</span>
                    <p class="projectCardDescFont">Publicly accessible</p>
                </div>
                
            </div>

            <div class="projectCardColumn clearFix">
                <img class="projectCardImage" src="user.png" alt="Image here">
                
                <div class="projectCardDesc">
                    <span class="projectCardTitle">Help</span>
                    <p class="projectCardDescFont">Learn how to understand spells and spellbooks</p>
                </div>
                
            </div>
            
        </div>
    </body>
</html>
