import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { SampleProductService } from '../sampleproduct.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampleproduct-print',
    templateUrl: './sampleproduct-print.component.html',
    styleUrls: ['./sampleproduct-print.component.css'],
})
export class SampleProductPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleProductService: SampleProductService, private route: ActivatedRoute) {
        this.vm = this.sampleProductService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.sampleProductService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }

    }
    
    onPrint() {
        window.print();
    }
   


}
