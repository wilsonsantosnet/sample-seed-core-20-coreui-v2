import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleService } from '../sample.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";

@Component({
    selector: 'app-sample-create',
    templateUrl: './sample-create.component.html',
    styleUrls: ['./sample-create.component.css'],
})
export class SampleCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
 
    constructor(private sampleService: SampleService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.sampleService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.sampleService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

        this.sampleService.save(model).subscribe((result) => {
            this.vm.model.sampleId = result.data.sampleId;
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleService.detectChangesStop();
    }
}
