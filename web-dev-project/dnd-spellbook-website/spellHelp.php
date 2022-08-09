<!DOCTYPE html>

<?php 
    $username = empty($_COOKIE['username']) ? '' : $_COOKIE['username'];
    session_unset();
    session_destroy();
?>

<html>
    
    <head lang="en">
        <meta charset="utf-8">
        <title>Help</title>
        
        <link rel="stylesheet" type="text/css" href="Styles.css">
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
            
            .videoCardColumn{
                width:420px;
                height: 236px;
                background-color: firebrick;
                border-width: 4px;
                border-style: ridge;
                border-color: darkgoldenrod;
                border-radius: 5px;
                box-shadow: 5px 5px black;
                width: 400px;
                height: 250px;
                position: relative;
                margin-left: auto;
                margin-right: auto;
                margin-top: 5%;
                margin-bottom: 5%;
                overflow:hidden;
            }
            
            .embededVid{
                width: 100%;
                height: 100%;
            }
        </style>
        
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        
        
    </head>
    
    <body id="bodyId" class="clearFix">
         <?php 
            switch($username){
                case '':
                    include("navOut.php");
                    break;
                    
                default:
                    include("navIn.php");
            }; ?>
        <div id="projectsWrapper">
            
            <div class="videoCardColumn clearFix">
                <iframe class="embededVid" src="https://www.youtube.com/embed/i9ZnlZ7VudM" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
               
                
            </div>

            <div class="videoCardColumn clearFix">
                <iframe class="embededVid" src="https://www.youtube.com/embed/gPP_13-kwBo" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
               
                
            </div>
            
            <div class="videoCardColumn clearFix" onclick="helpClick()">
                <iframe class="embededVid" src="https://www.youtube.com/embed/-eRyWCeMK9k" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                
            </div>
            
            <div class="videoCardColumn clearFix" onclick="helpClick()">
                <iframe class="embededVid" width="560" height="315" src="https://www.youtube.com/embed/k04sCi_cwtY" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                
            </div>
            
        </div>
        
    </body>
    
</html>