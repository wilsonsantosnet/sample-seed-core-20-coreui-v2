import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';

@Component({
    selector: 'app-sampledetail-details',
    templateUrl: './sampledetail-details.component.html',
    styleUrls: ['./sampledetail-details.component.css'],
})
export class SampleDetailDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleDetailService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.sampleDetailService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleDetailService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleDetailService.getInfoGrid(infos);
        });
    }

    
}
