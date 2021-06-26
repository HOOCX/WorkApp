<?php
require_once 'helpers/utilities.php';
require_once './layout/layout.php';
require_once './service/api.php';

$layout = new Layout(false);
$api = new API();
?>

<?php $layout->printHeader();var_dump($api->GET("user/getusers")) ?>

<br>
<br>
<br>
<div class="container-fluid">
    <div class="row">
        <div class="col-12 mt-3">
            <div class="card">
                <div class="card-horizontal">
                    <div class="img-square-wrapper">
                        <img class="" src="http://via.placeholder.com/300x180" alt="Card image cap">
                    </div>
                    <div class="card-body">
                        <h4 class="card-title">Card title</h4>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
                <div class="card-footer">
                    <small class="text-muted">Last updated 3 mins ago</small>
                </div>
            </div>
        </div>
    </div>
</div>

<?php $layout->printFooter();  ?>
