//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleProductService } from '../sampleproduct.service';

@Component({
    selector: 'app-sampleproduct-container-edit',
    templateUrl: './sampleproduct-container-edit.component.html',
    styleUrls: ['./sampleproduct-container-edit.component.css'],
})
export class SampleProductContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleProductService: SampleProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleProductService.initVM();
    }

    ngOnInit() {

       
    }

}
