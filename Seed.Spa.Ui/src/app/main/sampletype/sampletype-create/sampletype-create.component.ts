import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleTypeService } from '../sampletype.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";

@Component({
    selector: 'app-sampletype-create',
    templateUrl: './sampletype-create.component.html',
    styleUrls: ['./sampletype-create.component.css'],
})
export class SampleTypeCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
 
    constructor(private sampleTypeService: SampleTypeService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.sampleTypeService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.sampleTypeService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleTypeService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleTypeService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

        this.sampleTypeService.save(model).subscribe((result) => {
            this.vm.model.sampleTypeId = result.data.sampleTypeId;
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleTypeService.detectChangesStop();
    }
}
