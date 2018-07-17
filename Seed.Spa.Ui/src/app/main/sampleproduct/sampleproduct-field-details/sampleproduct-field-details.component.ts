
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampleproduct-field-details',
    templateUrl: './sampleproduct-field-details.component.html',
    styleUrls: ['./sampleproduct-field-details.component.css']
})
export class SampleProductFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
