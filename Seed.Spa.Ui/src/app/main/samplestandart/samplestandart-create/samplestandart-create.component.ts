import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";

@Component({
    selector: 'app-samplestandart-create',
    templateUrl: './samplestandart-create.component.html',
    styleUrls: ['./samplestandart-create.component.css'],
})
export class SampleStandartCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
 
    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.sampleStandartService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.sampleStandartService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleStandartService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleStandartService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

        this.sampleStandartService.save(model).subscribe((result) => {
            this.vm.model.sampleStandartId = result.data.sampleStandartId;
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleStandartService.detectChangesStop();
    }
}
