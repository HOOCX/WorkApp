<?php

class API
{
	private $urlBase;
	private $token;

	function __construct()
	{
		$this->urlBase = "https://progitla.azurewebsites.net/";
		$this->token = "Q1JWTURIUlVUSUVQU0tEREhGTkNNRkhSVUlFUFNMRnwyMDIxLTA2LTI2IDEzOjU2OjQ1LjAwMHwyMDIxLTA2LTI3IDEzOjU2OjQ1LjAwMA==";
	}
  
    static function Authentication()
    {
		$api = new API(); 
		$ch = curl_init();
		curl_setopt($ch, CURLOPT_URL,$api->urlBaseapi."/authenticate?user=Vicky27&pass=123");
		curl_setopt($ch, CURLOPT_RETURNTRANSFER,1);
		curl_setopt($ch, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
		$result = curl_exec($ch);
		curl_close($ch);  
		return $result;
	}

    static function POST($URL,$ARRAY)
    {
		$datapost = '';
		foreach($ARRAY as $key=>$value) 
        {
		    $datapost .= $key . "=" . $value . "&";
		}

		$api = new API(); 
		$headers 	= array('xToken:' . $api->token);
		$ch 		= curl_init();
		curl_setopt($ch,CURLOPT_URL,$api->urlBase.$URL);
		curl_setopt($ch,CURLOPT_POST, 1);
		curl_setopt($ch,CURLOPT_POSTFIELDS,$datapost);
		curl_setopt($ch,CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch,CURLOPT_CONNECTTIMEOUT ,3);
		curl_setopt($ch,CURLOPT_TIMEOUT, 20);
		curl_setopt($ch,CURLOPT_HTTPHEADER, $headers);
		$response = curl_exec($ch);
		curl_close ($ch);
		return $response;
	}

    static function GET($URL)
    {
		$api = new API(); 
		$headers 	= array('xToken:' . $api->token);
		$ch 		= curl_init();
		curl_setopt($ch,CURLOPT_URL,$api->urlBase.$URL);
		curl_setopt($ch,CURLOPT_RETURNTRANSFER,1);
		curl_setopt($ch,CURLOPT_TIMEOUT, 20);
		curl_setopt($ch,CURLOPT_HTTPHEADER, $headers);
		$response = curl_exec($ch);
		curl_close ($ch);
		return $response;
	}

    static function DELETE($URL){
		$api = new API(); 

		$headers 	= array('xToken:' . $api->token);
		$ch 		= curl_init();
		curl_setopt($ch,CURLOPT_URL,$api->urlBase.$URL);
		curl_setopt($ch,CURLOPT_CUSTOMREQUEST, "DELETE");
		curl_setopt($ch,CURLOPT_RETURNTRANSFER,1);
		curl_setopt($ch,CURLOPT_TIMEOUT, 20);
		curl_setopt($ch,CURLOPT_HTTPHEADER, $headers);
		$response = curl_exec($ch);
		curl_close ($ch);
		return $response;
	}

    static function PUT($URL,$ARRAY)
    {
		$datapost = '';
		foreach($ARRAY as $key=>$value) {
		    $datapost .= $key . "=" . $value . "&";
		}

		$api = new API(); 
		$headers 	= array('xToken:' . $api->token);
		$ch 		= curl_init();
		curl_setopt($ch,CURLOPT_URL,$api->urlBase.$URL);
		curl_setopt($ch,CURLOPT_CUSTOMREQUEST, "PUT");
		curl_setopt($ch,CURLOPT_POST, 1);
		curl_setopt($ch,CURLOPT_POSTFIELDS,$datapost);
		curl_setopt($ch,CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch,CURLOPT_CONNECTTIMEOUT ,3);
		curl_setopt($ch,CURLOPT_TIMEOUT, 20);
		curl_setopt($ch,CURLOPT_HTTPHEADER, $headers);
		$response = curl_exec($ch);
		curl_close ($ch);
		return $response;
	}

    static function PATCH($URL,$ARRAY)
    {
		$datapost = '';
		foreach($ARRAY as $key=>$value) {
		    $datapost .= $key . "=" . $value . "&";
		}

		$api = new API(); 
		$headers 	= array('xToken:' . $api->token);
		$ch 		= curl_init();
		curl_setopt($ch,CURLOPT_URL,$api->urlBase.$URL);
		curl_setopt($ch,CURLOPT_CUSTOMREQUEST, "PATCH");
		curl_setopt($ch,CURLOPT_POST, 1);
		curl_setopt($ch,CURLOPT_POSTFIELDS,$datapost);
		curl_setopt($ch,CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch,CURLOPT_CONNECTTIMEOUT ,3);
		curl_setopt($ch,CURLOPT_TIMEOUT, 20);
		curl_setopt($ch,CURLOPT_HTTPHEADER, $headers);
		$response = curl_exec($ch);
		curl_close ($ch);
		return $response;
	}

    static function JSON_TO_ARRAY($json){
		return json_decode($json,true);
	}

}
?>