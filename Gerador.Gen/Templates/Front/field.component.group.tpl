<div class="modal fade" id="<#componentId#>">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title pull-left"><#componentTitle#></h4>
        <button type="button" class="close pull-right" aria-label="Close" data-dismiss="modal">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body pre-scrollable">
        <#componentTag#>
      </div>
      <div class="modal-footer">
        <button class="btn btn-default " type="button" data-dismiss="modal" >
          <i class="icon-close icons"></i>
          {{vm.generalInfo.cancelar.label}}
        </button>
      </div>
    </div>
  </div>
</div>
