import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleStandartService } from '../samplestandart.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-samplestandart-field-edit',
    templateUrl: './samplestandart-field-edit.component.html',
    styleUrls: ['./samplestandart-field-edit.component.css']
})
export class SampleStandartFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private sampleStandartService: SampleStandartService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
