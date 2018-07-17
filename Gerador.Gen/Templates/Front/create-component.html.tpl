<section class="container-fluid">
	<form (ngSubmit)="onSave(vm.model)" novalidate>
	  <section class="card">
		<header class="card-header">
		  <div class="row align-items-center">
			<div class="col">
			  <span class="fa fa-angle-double-right" aria-hidden="true"></span> {{ vm.actionTitle }}<br>
			  <small class="text-muted">{{ vm.actionDescription }}</small>
			</div>
		  </div>
		</header>
		<article class="card-body">
			<app-<#classNameLowerAndSeparator#>-container-create [(vm)]="vm"></app-<#classNameLowerAndSeparator#>-container-create>
		</article>
		<footer class="card-footer  d-flex justify-content-end">
		  <a href="javascript:history.back()" class="btn btn-secondary">
				<i class="fa fa-reply"></i> Voltar
			</a>
		  <button type="submit" class="btn btn-success " [disabled]="vm != null && vm.form.invalid">
			<i class="icon-check icons"></i>
			{{vm.generalInfo.salvar.label}}
		  </button>
		</footer>
	  </section>
	</form>
</section>
