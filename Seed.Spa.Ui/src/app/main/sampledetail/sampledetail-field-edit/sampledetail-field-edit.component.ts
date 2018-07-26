import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleDetailService } from '../sampledetail.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-sampledetail-field-edit',
    templateUrl: './sampledetail-field-edit.component.html',
    styleUrls: ['./sampledetail-field-edit.component.css']
})
export class SampleDetailFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private sampleDetailService: SampleDetailService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
