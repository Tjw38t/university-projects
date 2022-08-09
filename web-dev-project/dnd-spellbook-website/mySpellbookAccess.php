<?php
// Created by Professor Wergeles for CS2830 at the University of Missouri
    $username = empty($_COOKIE['username']) ? '' : $_COOKIE['username'];
    
    if(!($username)){
        header("Location: menu.html");
		exit;
    }
    
    require_once "/db.conf";
    
    $mysqli = new mysqli($dbhost, $dbuser, $dbpass, $dbname);

    if ($mysqli->connect_error) {
        die('Connect Error (' . $mysqli->connect_errno . ') '
                . $mysqli->connect_error);
    }
    
    // If we're connected, we can print information about the host
    // http://php.net/manual/en/mysqli.get-host-info.php
    print "Connected! Status:" . $mysqli->host_info . "\n";
    
	$mysqli->close();
?>