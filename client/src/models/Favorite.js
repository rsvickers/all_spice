export class Favorite {
    constructor(data) {
        this.id = data.id || data._id
        this.createdAt = new Date(data.createdAt)
        this.updatedAt = new Date(data.updatedAt)
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.recipeId = data.recipeId
        this.accountId = data.accountId
        this.favoriteId = data.favoriteId
    }
}