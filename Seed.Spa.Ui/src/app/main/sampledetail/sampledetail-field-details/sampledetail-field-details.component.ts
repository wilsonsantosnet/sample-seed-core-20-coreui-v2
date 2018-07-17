
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampledetail-field-details',
    templateUrl: './sampledetail-field-details.component.html',
    styleUrls: ['./sampledetail-field-details.component.css']
})
export class SampleDetailFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
