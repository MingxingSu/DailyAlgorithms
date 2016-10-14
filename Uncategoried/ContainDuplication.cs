//Given an array of integers and an integer k, 
//find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k.
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        if(nums == null || nums.Length <=k)
        	return false;
        Dictionary<int,int> dict = new Dictionary<int,int>();

        for(int i = 0; i < nums.Length; i++){
        	if(dict.ContainsKey(nums[i])){
        			if(i-dict[nums[i]] <=k){
        				return true;
        			}
        			else{
        				dict[nums[i]]=i;
        			}	
        	}
        	else
        		dict.Add(nums[i],i);
        }
        return false;
    }
}