<?php

 class JobApiService{   

    private $context;

    public function __construct(){

        $this->utilities = new Utilities();
        $this->context = new API();

    }

    public function GetList(){

        $jobsList = array();

        $list = $this->context->GET("job/getjobs");
        $array = $this->context->JSON_TO_ARRAY($list);
        if (count($array) === 0) {
            return array();
        } else {

            foreach ($array as $item) {
                $element = new Job();
                $element->Set($item);
                array_push($jobsList, $element);
            }
        }

        return $jobsList;
    }  
}