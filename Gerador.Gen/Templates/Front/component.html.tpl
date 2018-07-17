﻿<!--EXT-->
<section class="container-fluid">

  <section class="card">
    <header class="card-header">
      <div class="row align-items-center">
        <div class="col">
          <span class="fa fa-edit" aria-hidden="true"></span> {{ vm.actionTitle }}<br>
          <small class="text-muted">{{ vm.actionDescription }}</small>
        </div>
        <div class="col text-right">
          <a *ngIf="_showBtnBack" class="btn py-0" href="javascript:history.back()" title="{{vm.generalInfo.voltar.label}}">
            <span class="fa fa-arrow-left" aria-hidden="true"></span> {{vm.generalInfo.voltar.label}}
          </a>
          <a *ngIf="_showBtnFilter" class="btn py-0" (click)="onShowFilter()" title="{{vm.generalInfo.filtro.label}}">
            <span class="fa fa-filter" aria-hidden="true"></span> {{vm.generalInfo.filtro.label}}
          </a>
          <a *ngIf="_showBtnNew" class="btn py-0" (click)="onCreate()" title="{{vm.generalInfo.novoItem.label}}">
            <span class="fa fa-plus" aria-hidden="true"></span> {{vm.generalInfo.novoItem.label}}
          </a>
        </div>
      </div>
    </header>
    <article class="card-body">
      <make-grid [(vm)]="vm" (edit)="onEdit($event)" (details)="onDetails($event)" (print)="onPrint($event)" (deleteConfimation)="onDeleteConfimation($event)" (orderBy)="onOrderBy($event)" [showPrint]="_showBtnPrint" [showDelete]="_showBtnDelete" [showDetails]="_showBtnDetails" [showEdit]="_showBtnEdit"></make-grid>
    </article>
    <footer class="card-footer">
      <make-pagination [(vm)]="vm" (pageChanged)="onPageChanged($event)"></make-pagination>
    </footer>
  </section>
</section>

<div bsModal #filterModal="bs-modal" class="modal fade">
  <div class="modal-dialog modal-lg">
    <form #formFilter="ngForm" (ngSubmit)="onFilter(vm.modelFilter)">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{vm.generalInfo.filtro.label}}</h5>
          <button type="button" class="close pull-right" aria-label="Close" (click)="onCancel()">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body pre-scrollable">
          <app-<#classNameLowerAndSeparator#>-container-filter [(vm)]="vm" *ngIf="_showContainerFilters"></app-<#classNameLowerAndSeparator#>-container-filter>
        </div>
        <div class="modal-footer">
          <button class="btn btn-default" type="button" (click)="onCancel()">
            <i class="icon-close icons"></i>
            {{vm.generalInfo.cancelar.label}}
          </button>
          <button class="btn btn-default" type="button" (click)="onClearFilter()">
            <i class="icon-reload icons"></i>
            {{vm.generalInfo.limpar.label}}
          </button>
          <button class="btn btn-success" type="submit">
            <span class="fa fa-search"></span>
            {{vm.generalInfo.filtrar.label}}
          </button>
        </div>
      </div>
    </form>
  </div>
</div>

<div bsModal #saveModal="bs-modal" class="modal fade">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title pull-left">Manutenção de {{ vm.actionTitle }}</h4>
        <button type="button" class="close pull-right" aria-label="Close" (click)="onCancel()">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <form (ngSubmit)="onSave(vm.model)" novalidate>
        <div class="modal-body pre-scrollable">
          <app-<#classNameLowerAndSeparator#>-container-create [(vm)]="vm" *ngIf="_showContainerCreate"></app-<#classNameLowerAndSeparator#>-container-create>
        </div>
        <div class="modal-footer">
          <div class="form-check form-check-inline mr-1">
            <input type='checkbox' [(ngModel)]='vm.manterTelaAberta' name='manterTelaAberta' class="form-check-input" />
            <label class="form-check-label" for="inline-checkbox1">Manter Aberta?</label>
          </div>
          <button class="btn btn-default" type="button" (click)="onCancel()">
			<i class="icon-close icons"></i>
			{{vm.generalInfo.cancelar.label}}
		  </button>
          <button type="submit" class="btn btn-success " [disabled]="vm != null && vm.form.invalid">
			<i class="icon-check icons"></i>
			{{vm.generalInfo.salvar.label}}
		  </button>
        </div>
      </form>
    </div>
  </div>
</div>

<div bsModal #editModal="bs-modal" class="modal fade">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title pull-left">Manutenção de {{ vm.actionTitle }}</h4>
        <button type="button" class="close pull-right" aria-label="Close" (click)="onCancel()">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <form (ngSubmit)="onSave(vm.model)" novalidate>
        <div class="modal-body pre-scrollable">
          <app-<#classNameLowerAndSeparator#>-container-edit [(vm)]="vm" *ngIf="_showContainerEdit"></app-<#classNameLowerAndSeparator#>-container-edit>
        </div>
        <div class="modal-footer">
          <div class="form-check form-check-inline mr-1">
            <input type='checkbox' [(ngModel)]='vm.manterTelaAberta' name='manterTelaAberta' class="form-check-input" />
            <label class="form-check-label" for="inline-checkbox1">Manter Aberta?</label>
          </div>
		  <button class="btn btn-default" type="button" (click)="onCancel()">
			<i class="icon-close icons"></i>
			{{vm.generalInfo.cancelar.label}}
		  </button>
          <button type="submit" class="btn btn-success " [disabled]="vm != null && vm.form.invalid">
			<i class="icon-check icons"></i>
			{{vm.generalInfo.salvar.label}}
		  </button>        
		 </div>
      </form>
    </div>
  </div>
</div>

<div bsModal #detailsModal="bs-modal" class="modal fade">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title pull-left">Detalhes de {{ vm.actionTitle }}</h4>
        <button type="button" class="close pull-right" aria-label="Close" (click)="onCancel()">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body pre-scrollable">
        <app-<#classNameLowerAndSeparator#>-container-details [(vm)]="vm" *ngIf="_showContainerDetails"></app-<#classNameLowerAndSeparator#>-container-details>
      </div>
      <div class="modal-footer">
        <button class="btn btn-default " type="button" (click)="onCancel()">
			<i class="icon-close icons"></i>
			{{vm.generalInfo.cancelar.label}}
		</button>
      </div>
    </div>
  </div>
</div>