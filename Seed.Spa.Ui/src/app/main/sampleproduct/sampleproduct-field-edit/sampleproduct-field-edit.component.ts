import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';

import { SampleProductService } from '../sampleproduct.service';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampleproduct-field-edit',
    templateUrl: './sampleproduct-field-edit.component.html',
    styleUrls: ['./sampleproduct-field-edit.component.css']
})
export class SampleProductFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private sampleProductService: SampleProductService, private ref: ChangeDetectorRef) { }

    ngOnInit() { }

    ngOnChanges() {
       this.ref.detectChanges()
    }

        

   
}
