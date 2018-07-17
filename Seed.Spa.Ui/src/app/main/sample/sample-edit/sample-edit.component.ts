import { Component, OnInit, Input,ChangeDetectorRef,OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleService } from '../sample.service';
import { GlobalService, NotificationParameters} from '../../../global.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from '../../../common/components/component.base';

@Component({
    selector: 'app-sample-edit',
    templateUrl: './sample-edit.component.html',
    styleUrls: ['./sample-edit.component.css'],
})
export class SampleEditComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleService: SampleService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {

        this.vm = this.sampleService.initVM();
        this.vm.actionDescription = "Edição";

        this.sampleService.detectChanges(this.ref);

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        this.sampleService.get({ id: this.id }).subscribe((data) => {
            this.vm.model = data.data;
            this.showContainerEdit();
        })

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
            if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation()])
        });
    }

    ngOnDestroy() {
        this.sampleService.detectChangesStop();
    }
}
