<?php

    class Job{

        public $Id;
        public $Name;
        public $Description;
        public $User_Id;
        public $Photo;
        public $State;

        public function initializeData($id,$name,$description,$user_id,$state)
        {
            $this->Id = $id;
            $this->Name = $name;
            $this->Description = $description;
            $this->User_Id = $user_id;
            $this->State = $state;                                         
        }

        public function Set($element){
            foreach($element as $key => $value){
                $this->{$key} = $value;
            }
        }

    }

?>