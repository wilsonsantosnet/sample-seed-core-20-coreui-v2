import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { SampleStandartService } from '../samplestandart.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-samplestandart-print',
    templateUrl: './samplestandart-print.component.html',
    styleUrls: ['./samplestandart-print.component.css'],
})
export class SampleStandartPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleStandartService: SampleStandartService, private route: ActivatedRoute) {
        this.vm = this.sampleStandartService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.sampleStandartService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }

    }
    
    onPrint() {
        window.print();
    }
   


}
