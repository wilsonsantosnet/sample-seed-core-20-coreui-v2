import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';

import { SampleStandartService } from '../samplestandart.service';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-samplestandart-field-edit',
    templateUrl: './samplestandart-field-edit.component.html',
    styleUrls: ['./samplestandart-field-edit.component.css']
})
export class SampleStandartFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private sampleStandartService: SampleStandartService, private ref: ChangeDetectorRef) { }

    ngOnInit() { }

    ngOnChanges() {
       this.ref.detectChanges()
    }

        

   
}
