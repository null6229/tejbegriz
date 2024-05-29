<?php

$conn=new mysqli("localhost","root","","almaleves");
if ($conn->connect_error) {
    die($conn->connect_error);
}
$conn->set_charset("utf8");
