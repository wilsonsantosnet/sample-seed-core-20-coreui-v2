import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleStandartService } from '../samplestandart.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-samplestandart-field-create',
    templateUrl: './samplestandart-field-create.component.html',
    styleUrls: ['./samplestandart-field-create.component.css']
})
export class SampleStandartFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
