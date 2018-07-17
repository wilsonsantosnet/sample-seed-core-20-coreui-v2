import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";

@Component({
    selector: 'app-sampledetail-create',
    templateUrl: './sampledetail-create.component.html',
    styleUrls: ['./sampledetail-create.component.css'],
})
export class SampleDetailCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
 
    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.sampleDetailService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.sampleDetailService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleDetailService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleDetailService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

        this.sampleDetailService.save(model).subscribe((result) => {
            this.vm.model.sampleDetailId = result.data.sampleDetailId;
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleDetailService.detectChangesStop();
    }
}
