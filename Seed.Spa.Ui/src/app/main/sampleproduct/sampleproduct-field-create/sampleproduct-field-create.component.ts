import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { SampleProductService } from '../sampleproduct.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-sampleproduct-field-create',
    templateUrl: './sampleproduct-field-create.component.html',
    styleUrls: ['./sampleproduct-field-create.component.css']
})
export class SampleProductFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private sampleProductService: SampleProductService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
