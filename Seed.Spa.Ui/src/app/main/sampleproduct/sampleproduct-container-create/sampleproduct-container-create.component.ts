//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleProductService } from '../sampleproduct.service';

@Component({
    selector: 'app-sampleproduct-container-create',
    templateUrl: './sampleproduct-container-create.component.html',
    styleUrls: ['./sampleproduct-container-create.component.css'],
})
export class SampleProductContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleProductService: SampleProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleProductService.initVM();
    }

    ngOnInit() {

       
    }

}
