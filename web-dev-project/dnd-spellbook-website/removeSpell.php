<?php
// Created by Professor Wergeles for CS2830 at the University of Missouri
    
   $username = empty($_COOKIE['username']) ? '' : $_COOKIE['username'];
    $index = empty($_GET['index']) ? '' : $_GET['index'];
    if(!($username && $index)){
        header("Location: menu.html");
		exit;
    }
    
    $dbhost = 'localhost';
    $dbuser = 'test';
    $dbpass = 'pass';
    $dbname = 'my_spellbook';
    
    $mysqli = new mysqli($dbhost, $dbuser, $dbpass, $dbname);

    if ($mysqli->connect_error) {
        die('Connect Error (' . $mysqli->connect_errno . ') '
                . $mysqli->connect_error);
    }
    
    $query = "DELETE FROM knownSpells WHERE known = " . $index;
    $mysqliResult = $mysqli->query($query);
    
	$mysqli->close();
    $mysqliResult->close();
    header("Location: MySpellbook.php");
    exit;
?>