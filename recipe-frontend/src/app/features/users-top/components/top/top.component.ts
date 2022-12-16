import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth_service';
import { User } from 'src/app/features/profile/models/user';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['../../../../../styles/top.component.css']
})
export class TopComponent implements OnInit {

  constructor(private userService: AuthService) { }

  ngOnInit(): void {
    this.userService.getAllUsers()
    .subscribe(value => {this.users = value})
  }

  users!: User[];

  filters: string[] = ["По лайкам", "По избранному", "По комментариям"]
  currentFilterNumber: number = 1;

  onChooseFilter(event: any){
      var currentFilter: string = event.target.value;
      switch (currentFilter){
        case this.filters[0]:
          this.currentFilterNumber = 1
          break;
        case this.filters[1]:
          this.currentFilterNumber = 2
          break;
        case this.filters[2]:
          this.currentFilterNumber = 3
          break;
        default:
          this.currentFilterNumber = 1;
      }
  }

  onSearch(form: NgForm){
    this.userService.searchUsers(this.currentFilterNumber, form.value.name)
    .subscribe(value => {this.users = value})
  }

}
