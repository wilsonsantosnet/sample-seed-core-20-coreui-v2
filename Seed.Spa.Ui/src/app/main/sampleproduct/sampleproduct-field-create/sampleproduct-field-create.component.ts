import { Component, OnInit, Input, ChangeDetectorRef} from '@angular/core';
import { SampleProductService } from '../sampleproduct.service';

import { ViewModel } from '../../../common/model/viewmodel';

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

   


}
