<?php
require_once "dbConn.php";
if(isset($_POST["gomb"])){
  $x = $_POST['x'];
  $y = $_POST['y'];
  $z = $_POST['z'];
  $stmt=$conn->prepare("INSERT INTO `almaleves`(`x`, `y`, `z`) VALUES (?, ?, ?)");
  $stmt->bind_param("sss", $x,$y,$z);
  if($stmt->execute()){
      http_response_code(201);
  }else{
      http_response_code(401);
  }
}
$script = "<script> window.location = '../tejbegriz/index.html';</script>";
echo $script;
