import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleStandartService } from '../samplestandart.service';

@Component({
    selector: 'app-samplestandart-details',
    templateUrl: './samplestandart-details.component.html',
    styleUrls: ['./samplestandart-details.component.css'],
})
export class SampleStandartDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleStandartService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.sampleStandartService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleStandartService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleStandartService.getInfoGrid(infos);
        });
    }

    
}
