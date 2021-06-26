<?php
require_once 'jobs.php';
require_once '../layout/layout.php';
require_once '../helpers/utilities.php';
require_once '../service/api.php';
require_once 'JobApiService.php';

$layout = new Layout(true);
$service = new JobApiService();
$jobs = $service->GetList();
?>

<?php $layout->printHeader();?>

<br>
<div class="container-fluid">
    <?php if(empty($jobs)):?>

        <h3 class="text-center">No hay empleos registrados</h3>

      <?php else: ?>
    <div class="row">
    <?php foreach($jobs as $job):?>
        <div class="col-12 mt-3">
            <div class="card">
                
                <div class="card-horizontal">
            
                    <div class="img-square-wrapper">
                    <?php if($job->Photo == null || $job->Photo == ''):?>
                        <img  src="<?php echo '../assets/img/default.png'; ?>" width="100%" height="225" aria-label="Placeholder: Thumbnail">
                      <?php else: ?>
                        <img  src="<?php echo '../assets/img/jobs/'.$job->Photo; ?>" width="100%" height="225" aria-label="Placeholder: Thumbnail">
                     <?php endif;?>
                    </div>
                    <div class="card-body">
                        <div class="container">
                        <h4 class="card-title"><?php echo $job->Name ?></h4>
                        <p class="card-text"><?php echo $job->Description ?></p> 
                        </div>
                     
                    </div>
                    <div style="margin-top:180px; margin-right:10px">
                        <button class="btn btn-success">Aplicar</button>
                    </div>
                </div>
                
                <div class="card-footer">
                    <small class="text-muted">Last updated 3 mins ago</small>
                </div>
            </div>
        </div>
        <?php endforeach; ?>
    </div>
    <?php endif;?>
  
</div>

<?php $layout->printFooter();  ?>

