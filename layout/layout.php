<?php

class Layout
{
  private $isRoot;
  private $directory;

  function __construct($page)
  {
    $this->isRoot = $page;
    $this->directory = ($this->isRoot) ? "../": "";
  }

  public function printHeader()
  {
    $header = <<<EOF
      <!DOCTYPE html>
      <html lang="en"><head>
          <meta charset="utf-8">
          <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">    
          <title>WORKAPP</title>
          
      <link rel="stylesheet" href="{$this->directory}assets/css/bootstrap.min.css" type="text/css">
      <link href="{$this->directory}assets/css/mdb.min.css" rel="stylesheet"/>
      <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css"rel="stylesheet"/>
      <link rel="stylesheet" href="{$this->directory}assets/css/style.css" type="text/css">
      </head>
      
        <body>
        <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom shadow-sm">
        <a class="my-0 mr-md-auto font-weight-normal text-dark navbar-brand" href="{$this->directory}index.php"><h5>WORKAPP</h5></a>
        <nav class="my-2 my-md-0 mr-md-3">
        <div class="input-group">
        <div class="form-outline">
          <input type="search" id="form1" class="form-control" />
          <label class="form-label" for="form1">Search</label>
        </div>
        <button type="button" class="btn btn-primary">
          <i class="fas fa-search"></i>
        </button>
      </div>
        </nav>
      
      </div>

    EOF;
    echo $header;
  }

  public function printFooter()
  {
    $footer = <<<EOF
      <footer class="footer">
 
      </footer>
      <script src="{$this->directory}assets/js/jquery/jquery-3.5.1.min.js"></script>
       <script src="{$this->directory}assets/js/vendor/popper.min.js"></script>
      <script src="{$this->directory}assets/js/bootstrap.min.js"></script>
      <script src="{$this->directory}assets/js/sweetalert.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.6.0/mdb.min.js"></script>
      
      </body>
      </html>
    EOF;
    echo $footer;
  }
} 

?>