import { Component, OnInit, Input, ChangeDetectorRef} from '@angular/core';
import { SampleDetailService } from '../sampledetail.service';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-sampledetail-field-create',
    templateUrl: './sampledetail-field-create.component.html',
    styleUrls: ['./sampledetail-field-create.component.css']
})
export class SampleDetailFieldCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;


   constructor(private sampleDetailService: SampleDetailService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

   


}
