<?php
    header('Content-Type: application/json; charset=utf-8');
    header('Access-Control-Allow-Origin: *');
    header('Access-Control-Allow-Headers: *');
    require_once "./dbConn.php";
    $query = explode('/', $_SERVER["QUERY_STRING"]);
    switch ($query[0]) {
        case 'krumpli':
            switch ($_SERVER["REQUEST_METHOD"]) {
                case 'GET':
                    $request = $conn->query("SELECT * FROM almaleves");
                    $data = $request->fetch_all(MYSQLI_ASSOC);
                    http_response_code(201);
                    echo json_encode($data);
                    break;
                case 'POST':
                    $x = filter_input(INPUT_POST, 'x');
                    $y = filter_input(INPUT_POST, 'y');
                    $z = filter_input(INPUT_POST, 'z');
                    $stmt=$conn->prepare("INSERT INTO `almaleves`('x','y','z') VALUES (?,?,?)");
                    $stmt->bind_param("sss", $x,$y,$z);
                    if($stmt->execute()){
                        http_response_code(201);
                    }else{
                        http_response_code(401);
                    }
                    break;
                default:
                    break;
            }
            break;
        default:
            http_response_code(401);
            break;
    }
