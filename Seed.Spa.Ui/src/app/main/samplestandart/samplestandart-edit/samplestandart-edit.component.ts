import { Component, OnInit, Input,ChangeDetectorRef,OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';
import { GlobalService, NotificationParameters} from '../../../global.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from '../../../common/components/component.base';

@Component({
    selector: 'app-samplestandart-edit',
    templateUrl: './samplestandart-edit.component.html',
    styleUrls: ['./samplestandart-edit.component.css'],
})
export class SampleStandartEditComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {

        this.vm = this.sampleStandartService.initVM();
        this.vm.actionDescription = "Edição";

        this.sampleStandartService.detectChanges(this.ref);

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        this.sampleStandartService.get({ id: this.id }).subscribe((data) => {
            this.vm.model = data.data;
            this.showContainerEdit();
        })

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
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleStandartService.detectChangesStop();
    }
}
