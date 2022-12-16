import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Recipe } from 'src/app/core/models/recipe';
import { Tag } from 'src/app/core/models/tag';
import { RecipeService } from 'src/app/core/services/recipe_service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['../../../../../styles/search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private recipeServ: RecipeService){}

  @Output() childComponentValue = new EventEmitter<any>();

  ngOnInit(): void {
    this.recipeServ.getAllTags()
    .subscribe(value => {this.tags = value})
  }

  tags: Tag[] = [];
  selectedTags: number[] = [];
  name!: string;
  recipes!: Recipe[];
  addedTags: string[] = [];

  onAddTag(event: any){
    var tagid: number = event.target.value;
    this.addedTags.push(this.tags.find(t => t.id == tagid)!.name as string);
    this.selectedTags.push(tagid);
  }

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
    this.recipeServ.getSearchingRecipes(this.selectedTags, form.value.name, this.currentFilterNumber)
      .subscribe(value => {
        this.recipes = value
        this.childComponentValue.emit(this.recipes);
      })
    console.log(this.recipes);
  }

  onDeleteTag(tag: string){
    var indexSel: number = this.selectedTags.indexOf(this.tags.find(t => t.name == tag)?.id as number);
    var indexAdd: number = this.addedTags.indexOf(tag);
    this.selectedTags.splice(indexSel, 1);
    this.addedTags.splice(indexAdd, 1);
  }
  
}
