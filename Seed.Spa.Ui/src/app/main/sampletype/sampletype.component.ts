import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl} from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { SampleTypeService } from './sampletype.service';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService, NotificationParameters} from '../../global.service';
import { ComponentBase } from '../../common/components/component.base';
import { LocationHistoryService } from '../../common/services/location.history';

@Component({
    selector: 'app-sampletype',
    templateUrl: './sampletype.component.html',
    styleUrls: ['./sampletype.component.css'],
})
export class SampleTypeComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;

    vm: ViewModel<any>;
	
    operationConfimationYes: any;
    changeCultureEmitter: EventEmitter<string>;

    @ViewChild('filterModal') private filterModal: ModalDirective;
    @ViewChild('saveModal') private saveModal: ModalDirective;
    @ViewChild('editModal') private editModal: ModalDirective;
    @ViewChild('detailsModal') private detailsModal: ModalDirective;
    
    constructor(private sampleTypeService: SampleTypeService, private router: Router, private ref: ChangeDetectorRef) {

        super();
        this.vm = null;

    }

    ngOnInit() {

        this.vm = this.sampleTypeService.initVM();
        this.configurationForParent();

        if (this.parentIdValue) 
            this.vm.modelFilter[this.parentIdField] = this.parentIdValue;

        this.sampleTypeService.detectChanges(this.ref);
        this.sampleTypeService.OnHide(this.saveModal, this.editModal, () => { this.hideComponents() });

        this.sampleTypeService.get(this.vm.modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
        });

        this.updateCulture();

        this.changeCultureEmitter = GlobalService.getChangeCultureEmitter().subscribe((culture : any) => {
            this.updateCulture(culture);
        });

        if (this._navigatioModal)
            LocationHistoryService.saveLocal("sampletype");

        this.vm.isParent = this.isParent;
        this.vm.ParentIdField = this.parentIdField;
    }

    configurationForParent() {
        if (this.isParent) {
            this._showBtnBack = false;
            this._showBtnFilter = false;
            this._showBtnDetails = false;
            this._showBtnPrint = false;
        }
    }

    updateCulture(culture: string = null)
    {
        this.sampleTypeService.updateCulture(culture).then((infos : any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleTypeService.getInfoGrid(infos);
        });
        this.sampleTypeService.updateCultureMain(culture).then((infos: any) => {
            this.vm.generalInfo = infos;
        });
    }


    public onFilter(modelFilter: any) {

        this.sampleTypeService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
            this.filterModal.hide();
        })
    }

    public onExport() {
        this.sampleTypeService.export().subscribe((result) => {
            var blob = new Blob([result.blob()], {
                type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
            });
            var downloadUrl = window.URL.createObjectURL(blob);
            window.location.href = downloadUrl;
        })
    }

    public onCreate() {

        this.showContainerCreate();

        this.vm.model = {};
        if (this.parentIdValue)
            this.vm.model[this.parentIdField] = this.parentIdValue;

        this.navigateStrategy(this.saveModal, this.router, "/sampletype/create");
    }

    public onEdit(model: any) {

        this.vm.model = {};
        let newModel : any = model;
        if (model)  {
            newModel = { id: model.sampleTypeId }
        }

        if (!this._navigatioModal) {
            this.navigateStrategy(this.editModal, this.router, "/sampletype/edit/" + newModel.id);
        }
        else {
            this.sampleTypeService.get(newModel).subscribe((result) => {
				      this.vm.model = result.dataList ? result.dataList[0] : result.data;
				      this.showContainerEdit();
				      this.editModal.show();
            })
        }
    }

    public onSave(model: any) {

        this.sampleTypeService.save(model).subscribe((result) => {

            this.vm.filterResult = this.vm.filterResult.filter(function (model) {
                return  model.sampleTypeId != result.data.sampleTypeId;
            });

            this.vm.model.sampleTypeId = result.data.sampleTypeId;
            this.vm.filterResult.push(result.data);
            this.vm.summary.total = this.vm.filterResult.length

            if (!this.vm.manterTelaAberta) {
                this.saveModal.hide();
                this.editModal.hide();
                this.hideContainerCreate();
                this.hideContainerEdit();
            }

        });

    }

    public onDetails(model: any) {
    
        this.vm.details = {};
        let newModel : any = model;
        if (model)
        {
            newModel = { id: model.sampleTypeId }
        }
		
        if (!this._navigatioModal) {
            this.navigateStrategy(this.editModal, this.router, "/sampletype/details/" + newModel.id);
        }
        else {
            this.sampleTypeService.get(newModel).subscribe((result) => {
				      this.vm.details = result.dataList ? result.dataList[0] : result.data;
				      this.showContainerDetails();
				      this.detailsModal.show();
            })
        }

    }

    public onCancel() {

        this.saveModal.hide();
        this.editModal.hide();
        this.detailsModal.hide();
        this.filterModal.hide();
        this.hideComponents();
    }

    public onShowFilter() {
        this.showContainerFilters();
        this.filterModal.show();
    }

    public onClearFilter() {
        this.vm.modelFilter = {};
        GlobalService.getNotificationEmitter().emit(new NotificationParameters("init", {
            model: {}
        }));
    }

    public onPrint(model: any) {
        this.router.navigate(['/sampletype/print', model.sampleTypeId]);
    }

    public onDeleteConfimation(model: any) {

        var conf = GlobalService.operationExecutedParameters(
            "confirm-modal",
            () => {
                let newModel : any = model;
                if (model)
                {    
                    newModel = { id: model.sampleTypeId }
                }
                this.sampleTypeService.delete(newModel).subscribe((result) => {
                    this.vm.filterResult = this.vm.filterResult.filter(function (model) {
                        return  model.sampleTypeId != result.data.sampleTypeId;
                    });
                    this.vm.summary.total = this.vm.filterResult.length
                });
            }
        );

        GlobalService.getOperationExecutedEmitter().emit(conf);
    }

    public onConfimationYes() {
        this.operationConfimationYes();
    }

    public onPageChanged(pageConfig: any) {

        let modelFilter = this.sampleTypeService.pagingConfig(this.vm.modelFilter, pageConfig);
        this.sampleTypeService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
        });
    }

    public onOrderBy(order: any) {

        let modelFilter = this.sampleTypeService.orderByConfig(this.vm.modelFilter, order);
        this.sampleTypeService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
        });
    }

    ngOnDestroy() {
        this.changeCultureEmitter.unsubscribe();
        this.sampleTypeService.detectChangesStop();
    }

}
