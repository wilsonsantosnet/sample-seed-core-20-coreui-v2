import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleProductService } from '../sampleproduct.service';

@Component({
    selector: 'app-sampleproduct-details',
    templateUrl: './sampleproduct-details.component.html',
    styleUrls: ['./sampleproduct-details.component.css'],
})
export class SampleProductDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleProductService: SampleProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleProductService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.sampleProductService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.sampleProductService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.sampleProductService.getInfoGrid(infos);
        });
    }

    
}
