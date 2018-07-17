import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { SampleDetailService } from '../sampledetail.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampledetail-print',
    templateUrl: './sampledetail-print.component.html',
    styleUrls: ['./sampledetail-print.component.css'],
})
export class SampleDetailPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute) {
        this.vm = this.sampleDetailService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.sampleDetailService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }

    }
    
    onPrint() {
        window.print();
    }
   


}
